import * as readline from 'readline-sync';

let bedrag = readline.questionInt("Geef het bedrag in: ");
let percent = readline.questionInt("Geef het interest percentage in: ");
let totaal = 0;

for(let i : number = 1; i < 10; i++){
    totaal = bedrag * Math.pow((1+percent/100),i);

    console.log(`Na ${i} jaar heb je ${totaal.toFixed(1)}`);
}