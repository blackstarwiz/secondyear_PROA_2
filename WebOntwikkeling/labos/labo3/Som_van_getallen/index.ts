import { read } from "fs";
import * as readline from "readline-sync";


let aantalGetallen : number= readline.questionInt("Hoeveel getallen wil je optellen: ");
let total : number = 0;


for(let i : number = 0; i<aantalGetallen; i++){

    let inputGetal = readline.questionInt("geef getal in: ");

    total += inputGetal;
}

console.log(`De som van de getallen is: ${total}`);