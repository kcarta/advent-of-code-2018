const should = require('should');
const Device = require('./puzzle');

describe('device', () => {

    const device = new Device();

    describe('reading frequency changes from file', () => {

        it('reads a changes file to produce a list of changes', async () => {
            const result = await device.read('test/simple-input');
            result.should.deepEqual([1, 2, 3]);
        });

        it('removes plus signs from inputs in file', async () => {
            const result = await device.read('test/complex-input');
            result.should.deepEqual([1, 2, -3]);
        });

    });

    describe('applying frequency changes', () => {

        it('stops when it reaches a frequency for the second time', () => {
            const frequency = 0;
            const changes = [1, 2, -3, -1];
            const result = device.applyChanges(frequency, changes);
            result.should.be.exactly(0);
        });

        it('continues reading until it meets a duplicate frequency', () => {
            const frequency = 0;
            const changes = [7, 7, -2, -7, -4];

            const result = device.applyChanges(frequency, changes);
            result.should.be.exactly(14);
        });

    });
});
