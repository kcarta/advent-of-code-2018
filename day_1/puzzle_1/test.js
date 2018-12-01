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

        it('adds positive changes to the current frequency', () => {
            const frequency = 0;
            const changes = [1, 2, 3];
            const result = device.applyChanges(frequency, changes);
            result.should.be.exactly(6);
        });

        it('subtracts negative changes from the current frequency', () => {
            const frequency = 0;
            const changes = [-1, -2, -3];
            const result = device.applyChanges(frequency, changes);
            result.should.be.exactly(-6);
        });

        it('adds and subtracts accordingly from the current frequency when given positive and negative changes', () => {
            const frequency = 0;
            const changes = [1, -2, 3];
            const result = device.applyChanges(frequency, changes);
            result.should.be.exactly(2);
        });

    });

});
