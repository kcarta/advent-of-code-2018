const fs = require('fs');
const util = require('util');
const readFile = util.promisify(fs.readFile);

module.exports = Device;

function Device() {

    Device.prototype.createFabric = () => {
        return Array(1200).fill().map(() => Array(1200).fill(0));
    }

    Device.prototype.countOverlaps = (fabric) => {
        return fabric.reduce((row, acc) => acc.concat(row), [])
            .filter((cell) => cell > 1).length;
    }

    Device.prototype.logClaims = (claims, fabric) => {
        const recordedClaims = {};
        claims.forEach((claim) => {
            // {x, y, w, h}
            // fill every column as many as height (+y) has down, as many as the width (+x) has to the right
            const startX = claim.x;
            const endX = startX + claim.w
            const startY = claim.y;
            const endY = claim.y + claim.h;
            let hasNoOverlaps = true;
            for (let i = startX; i < endX; i++) {
                for (let j = startY; j < endY; j++) {
                    fabric[j][i] += 1;
                }
            }
        });
        return {
            fabric
        };
    }

    Device.prototype.read = async (path) => {
        const lines = await readFile(path);
        return lines.toString().split(/\r\n|\n/).map(
            (line) => {
                const tokens = line.split(' ');
                /* [#num, @, x,y:, wxh] */
                const id = tokens[0];
                const coordTokens = tokens[2].slice(0, -1).split(',');
                const dimensionTokens = tokens[3].split('x');
                const [x, y] = coordTokens.map(Number);
                const [w, h] = dimensionTokens.map(Number);
                return { id, x, y, w, h, }
            }
        );
    };
};