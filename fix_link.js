const fs = require('fs');
const path = require('path');

function walkSync(currentDirPath) {
    fs.readdirSync(currentDirPath).forEach(function (name) {
        var filePath = path.join(currentDirPath, name);
        var stat = fs.statSync(filePath);
        if (stat.isFile() && filePath.endsWith('.md')) {
            let content = fs.readFileSync(filePath, 'utf8');
            if (content.includes('[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)')) {
                // If it's deeper, like databaze/ nebo knihovna/, fix it to ../../README.md
                const slashes = (filePath.match(/\|\//g) || []).length;
                let correctLink = '[<kbd> ⮞ Zpět na úvodní stránku </kbd>](' + '../'.repeat(slashes) + 'README.md)';
                content = content.replace('[<kbd> ⮞ Zpět na úvodní stránku </kbd>](../README.md)', correctLink);
                fs.writeFileSync(filePath, content, 'utf8');
            }
        } else if (stat.isDirectory() && !filePath.includes('.git') && !filePath.includes('node_modules')) {
            walkSync(filePath);
        }
    });
}

walkSync('./programming-oop');
console.log('Done fixing links.');
