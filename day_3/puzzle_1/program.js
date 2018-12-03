const Device = require('./puzzle');

(async function () {
    const device = new Device();
    const fabric = device.createFabric();
    const claims = await device.read('input');
    const logResult = device.logClaims(claims, fabric);
    const filledFabric = logResult.fabric;
    const result = device.countOverlaps(filledFabric);
    for (let id in logResult.recordedClaims) {
        if (logResult.recordedClaims[id].hasNoOverlaps) {
            console.log(`found one at: ${logResult.recordedClaims[id].id}`);
        }
    }
    console.log(`result is ${result}`);
})()