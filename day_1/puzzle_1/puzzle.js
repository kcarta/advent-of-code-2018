const fs = require('fs');
const util = require('util');
const readFile = util.promisify(fs.readFile);

module.exports = Device;

function Device() {
    Device.prototype.applyChanges = (startingFrequency, changes) => {
        return changes.reduce((accumulator, current) => accumulator + current, startingFrequency);
    };

    Device.prototype.read = async (path) => {
        const lines = await readFile(path);
        const changes = lines.toString().split(/\r\n|\n/).map((line) => parseInt(line));
        return changes;
    };
};