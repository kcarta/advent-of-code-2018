const Device = require('./puzzle');

(async function () {
    const device = new Device();
    const input = await device.read('input');
    const result = device.applyChanges(0, input);
    console.log(`result is ${result}`);
})()