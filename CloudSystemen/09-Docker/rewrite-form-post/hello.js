const express = require('express');
const bodyParser = require('body-parser');

const app = express();
const port = 3000;

// Body parser middleware to parse form data
app.use(bodyParser.urlencoded({ extended: false }));

// GET-handler voor het pad "/"
app.get('/', (req, res) => {
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

