import * as readline from 'readline-sync';

let done:boolean = true;

do{
    let namen : string[] = [];
    let lengte : number[] = [];
    let gewicht : number[] = [];

    let bmi : number[] = [];

    let aantalP = readline.questionInt("Geef het aantal personen in: ");

    for(let i : number = 0; i < aantalP; i++){
        namen[i] = readline.question(`Geef de naam van person ${i+1} in: `);
        lengte[i] = readline.questionInt(`Geef de lengte van ${namen[i]} in (cm): `);
        gewicht[i] = readline.questionInt(`Geef het gewicht van ${namen[i]} in (KG): `);
    }  
    
    for(let i : number = 0; i < namen.length; i++){
        let gewichtP : any  = gewicht[i];
        let lengteP : any = lengte[i];
        bmi[i] = (gewichtP*10000)/(lengteP  * lengteP);

        console.log(`${namen[i]} heeft een BMI van ${bmi[i]?.toFixed(2)}`);
        done = false;
    }

}while(done)
