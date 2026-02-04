import * as readline from 'readline-sync';

let totaalMinuten : number = readline.questionInt("Geef het aantal in minuten in: ");

let uren : number = Math.floor(totaalMinuten/60);

let minuten : number = totaalMinuten % 60;

console.log(`${uren} uur en ${minuten} minuten`);