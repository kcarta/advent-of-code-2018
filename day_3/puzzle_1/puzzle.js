const fs = require('fs');
const util = require('util');
const readFile = util.promisify(fs.readFile);

module.exports = Device;

function Device() {

    Device.prototype.createFabric = () => {
        return Array(1200).fill().map(() => Array(1200).fill({}));
    }

    Device.prototype.countOverlaps = (fabric) => {
        return fabric.reduce((row, acc) => acc.concat(row), [])
            .filter((cell) => cell.count > 1).length;
    }

    Device.prototype.logClaims = (claims, fabric) => {
        const recordedClaims = {};
        claims.forEach((claim) => {
            const startX = claim.x;
            const endX = startX + claim.w
            const startY = claim.y;
            const endY = claim.y + claim.h;
            let hasNoOverlaps = true;
            for (let i = startX; i < endX; i++) {
                for (let j = startY; j < endY; j++) {
                    let currentCell = fabric[j][i];
                    if (!Number.isInteger(currentCell.count)) {
                        currentCell = { count: 0, ids: [] };
                    }
                    currentCell.count += 1;
                    currentCell.ids.push(claim.id);
                    if (currentCell.count > 1) {
                        hasNoOverlaps = false;
                        currentCell.ids.filter((id) => recordedClaims[id])
                            .forEach((id) => recordedClaims[id].hasNoOverlaps = false);
                    }
                    fabric[j][i] = currentCell;
                }
            }
            recordedClaims[claim.id] = {
                id: claim.id,
                hasNoOverlaps,
            }
        });
        return {
            recordedClaims,
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