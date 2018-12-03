const chai = require('chai');
const expect = chai.expect;
const Device = require('./puzzle');

describe('device', () => {

    const device = new Device();

    describe('reading claims from file', () => {

        it('reads a claims file to produce a list of claims', async () => {
            const result = await device.read('test/simple-input');
            expect(result).to.deep.equal([
                { id: "#1", x: 555, y: 891, w: 18, h: 12 },
                { id: "#2", x: 941, y: 233, w: 16, h: 14 },
                { id: "#3", x: 652, y: 488, w: 16, h: 25 },
            ]);
        });

    });

    describe('creating a fabric space', () => {

        it('starts with a 1000x1000 grid, with every cell set to 0', () => {
            const grid = device.createFabric();
            expect(grid).to.be.an('array'); // How do I assert every cell to be 0 in a way that isn't insane?
        });

    });

    describe('logging claims into the fabric space', () => {

        it('increments the count in each cell in the fabric that the claims take up', () => {
            const claims = [
                { id: "#1", x: 0, y: 0, w: 1, h: 2 },
                { id: "#2", x: 1, y: 1, w: 1, h: 1 },
            ];
            const fabric = [
                [{ count: 0, ids: [] }, { count: 0, ids: [] }],
                [{ count: 0, ids: [] }, { count: 0, ids: [] }],
            ];
            const expected = [
                [{ count: 1, ids: ["#1"] }, { count: 0, ids: [] }],
                [{ count: 1, ids: ["#1"] }, { count: 1, ids: ["#2"] }]
            ];

            const result = device.logClaims(claims, fabric).fabric;

            expect(result).to.deep.equal(expected);
        });

        it('logs the id of each claim into the spaces the claim occupies', () => {
            const claims = [
                { id: "#1", x: 0, y: 0, w: 1, h: 1 },
                { id: "#2", x: 1, y: 1, w: 1, h: 1 },
            ];
            const fabric = [
                [{ count: 0, ids: [] }, { count: 0, ids: [] }],
                [{ count: 0, ids: [] }, { count: 0, ids: [] }],
            ];

            const result = device.logClaims(claims, fabric).fabric;

            /*
                [1, 0]
                [0, 1]
            */
            expect(result[0][0].ids[0]).to.equal("#1");
            expect(result[1][1].ids[0]).to.equal("#2");
        });

    });

    describe('counting overlapping claims', () => {
        it('returns the number of times more than one claim is made for a cell in the fabric', () => {
            const fabric = [
                [{ count: 0 }, { count: 1 }, { count: 1 }],
                [{ count: 1 }, { count: 2 }, { count: 3 }],
                [{ count: 1 }, { count: 1 }, { count: 2 }],
            ];

            const result = device.countOverlaps(fabric);

            expect(result).to.equal(3);
        });
    });

    describe('finding non-overlapping claims', () => {
        it('lists the ids of the claims with no overlaps', () => {

        });
    });
});
