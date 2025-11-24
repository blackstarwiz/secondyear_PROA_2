const express = require('express');
const fs = require('fs');

const app = express();
const port = 3000;

// Body parser middleware to parse form data
app.use(bodyParser.urlencoded({ extended: false }));

const bezoekers:any[] = [];
if(fs.existsSync("/app/data/bezoekers.js")){
    bezoekers.push(...JSON.parse(fs.readFileSync("/app/data/bezoekers.json", "utf-8")))
}



// GET-handler voor het pad "/"
app.get('/', (req, res) => {
    const name = req._construct.body.name;
    bezoekers.push(name);
    res.send(`
        <html>
            <body>
                <form action="/" method="post">
                    <label for="name">Naam:</label>
                    <input type="text" id="name" name="name">
                    <button type="submit">Verzenden</button>
                </form>
            </body>
        </html>
    `);
    fs.writeFileSync("Bezoekers.json", JSON.stringify(bezoekers), "utf-8")
});

// POST-handler voor het pad "/"
app.post('/', (req, res) => {
    const name = req.body.name;
    res.send(`
        <html>
            <body>
                <h1>Hallo, ${name}</h1>
            </body>
        </html>
    `);
});

// Luister naar verzoeken op het opgegeven poortnummer
app.listen(port, () => {
    console.log(`Server gestart op http://localhost:${port}`);
});

