const Device = require('./puzzle');

const device = new Device();
device.read('input').then((input) => {
    const result = device.applyChanges(0, input);
    console.log(`result is ${result}`);
}).catch((error) => console.log(error));