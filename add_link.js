const fs = require('fs');
const path = require('path');

const linkText = "\n\n---\n*Užitečný odkaz pro řešení problémů ve Windows Forms: [StackOverflow - This visible is not working in Windows Forms](https://stackoverflow.com/questions/3742709/this-visible-is-not-working-in-windows-forms)*\n";

function walkSync(currentDirPath) {
    fs.readdirSync(currentDirPath).forEach(function (name) {
        var filePath = path.join(currentDirPath, name);
        var stat = fs.statSync(filePath);
        if (stat.isFile() && filePath.endsWith('.md')) {
            let content = fs.readFileSync(filePath, 'utf8');
            if (!content.includes('stackoverflow.com/questions/3742709')) {
                // Insert before the back link if it exists
                if (content.includes('[<kbd> ⮞ Zpět na úvodní stránku </kbd>]')) {
                    content = content.replace('[<kbd> ⮞ Zpět na úvodní stránku </kbd>]', linkText + '\n[<kbd> ⮞ Zpět na úvodní stránku </kbd>]');
                } else {
                    content += linkText;
                }
                fs.writeFileSync(filePath, content, 'utf8');
            }
        } else if (stat.isDirectory() && !filePath.includes('.git') && !filePath.includes('node_modules')) {
            walkSync(filePath);
        }
    });
}

walkSync('./programming-oop');
console.log('Done appending links.');
