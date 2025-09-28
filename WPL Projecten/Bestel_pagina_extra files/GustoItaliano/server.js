const express = require("express");
const app = express();
const port = 3000;

// Middleware voor POST data
app.use(express.urlencoded({ extended: true }));
app.use(express.static("public")); // voor afbeeldingen, css, js, ...

// Data
let menu = [
  { naam: "Margherita", foto: "/images/margherita.jpg" },
  { naam: "Pepperoni", foto: "/images/pepperoni.jpg" },
  { naam: "Vegetariana", foto: "/images/vegetariana.jpg" },
  { naam: "Tonno", foto: "/images/tonno.jpg" },
  { naam: "Quattro Formaggi", foto: "/images/quattro_fromaggi.jpg" },
  { naam: "Diavola:", foto: "/images/diavola.jpg" }
];

let bestellingen = [];

// EJS instellen
app.set("view engine", "ejs");

// Route: home
app.get("/", (req, res) => {
  res.render("bestel_pagina", { menu, bestellingen });
});

// Route: bestelling toevoegen
app.post("/bestel", (req, res) => {
  const pizza = req.body.pizza;
  if (pizza) {
    bestellingen.push(pizza);
  }
  res.redirect("/");
});

// Nieuwe route: bestelling verwijderen op basis van index
app.post("/bestel/verwijder", (req, res) => {
  const idx = parseInt(req.body.index, 10);
  if (!Number.isNaN(idx) && idx >= 0 && idx < bestellingen.length) {
    bestellingen.splice(idx, 1);
  }
  res.redirect("/");
});

// Server starten
app.listen(port, () => {
  console.log(`Server draait op http://localhost:${port}`);
});
