import { read } from 'fs';
import * as readline from 'readline-sync';
let name = readline.question("whats yout name?: ")

console.log(`Hello ${name}`);

let age: number | undefined = undefined;
do{
    age = Number(readline.question("Enter your age: "));
    if(isNaN(age)){
        console.log("Input valid number, please.");
    }
}while(isNaN(age));
console.log(`your age is ${age}`)


let age1: number = readline.questionInt("What your age? ", {limitMessage: "I only like numbers"});
console.log(`your age is ${age1}`)



let choices : string[] = ["Javascript", "Typescript", "Python", "Rust"];

let index : number = readline.keyInSelect(choices, "Whats your favorite language");

console.log(`you choose ${choices[index]}`)
