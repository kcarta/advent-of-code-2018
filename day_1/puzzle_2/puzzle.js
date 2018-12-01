const fs = require('fs');
const util = require('util');
const readFile = util.promisify(fs.readFile);

module.exports = Device;

function Device() {
    Device.prototype.applyChanges = (frequency, changes) => {
        const recordedFrequencies = new Set([frequency]);
        let currentChanges = [...changes];
        while (true) {
            if (currentChanges.length === 0) {
                currentChanges = currentChanges.concat(changes);
            }
            frequency += currentChanges.shift();
            if (recordedFrequencies.has(frequency)) {
                return frequency;
            }
            recordedFrequencies.add(frequency);
        }
        // I wish I could use this, but I couldn't figure out how to get Node to support tail call optimization so I had to do a stupid imperative solution :'(
        // return applyChangesRec(frequency, changes, recordedFrequencies, [...changes]);
    };

    function applyChangesRec(frequency, currentChanges, recordedFrequencies, originalChanges) {
        if (currentChanges.length === 0) {
            currentChanges = currentChanges.concat(originalChanges);
        }
        const newFrequency = frequency + currentChanges.shift();
        return recordedFrequencies.has(newFrequency) ? newFrequency : applyChangesRec(newFrequency, currentChanges, recordedFrequencies.add(newFrequency), originalChanges);
    }

    Device.prototype.read = async (path) => {
        const lines = await readFile(path);
        const changes = lines.toString().split(/\r\n|\n/).map((line) => Number(line));
        return changes;
    };
};