import * as readline from 'readline-sync';

let woord : string = readline.question("Geef een woord in: ");
let sideWoord : string = woord.padStart(woord.length+2,"| ").padEnd(woord.length+4," |"); 


let topNbottom : string = "+" + "-".repeat(woord.length + 2) + "+";//chatgpt versie

//"-".repeat(sideWoord.length-2).padStart(sideWoord.length-1,"+").padEnd(sideWoord.length,"+"); --> mijn versie

console.log(topNbottom);
console.log(sideWoord);
console.log(topNbottom);
