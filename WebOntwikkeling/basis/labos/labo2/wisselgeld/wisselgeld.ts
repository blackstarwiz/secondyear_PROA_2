import * as readline from 'readline-sync';

let bedrag = readline.questionFloat("Geef een bedrag in: ");
let totalConvert : number = 0;
const eenheden : number[] = [100,50,20,10,5,2,1,0.5,0.2,0.1,0.05];
const resultaat: {[key:number] : number} = {};

for(let eenheid of eenheden){
    if(bedrag <= 0.5){
        resultaat[eenheid] = Math.round(bedrag/eenheid);
        bedrag %= eenheid;
    }else{
        resultaat[eenheid] = bedrag/eenheid;
        bedrag %= eenheid;
    }
    
}

for(let eenheid of eenheden){
    if(resultaat[eenheid]){
        totalConvert += resultaat[eenheid] * eenheid;
    }
}
console.log("Het kleinste aantal briefjes en munten:");
for(let eenheid of eenheden){
    if(resultaat[eenheid])
    console.log(`${eenheid} EUR: ${Math.round(resultaat[eenheid])}`);
}
console.log(`totaal bedrag converted: ${totalConvert.toFixed(2)}`);