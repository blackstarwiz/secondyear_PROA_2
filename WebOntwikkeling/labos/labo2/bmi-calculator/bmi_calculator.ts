import * as readline from 'readline-sync';

let done:boolean = false;

do{
    let gewicht : number = readline.questionInt("wat is je gewicht in (KG): ");
    let lengte : number = readline.questionInt("wat is je lengte in (cm): ");

    try{

        if(gewicht < 0 || lengte < 0){
            throw new TypeError("waarde moet positief zijn");
        }
    
        let bmi : number = (gewicht*10000)/(lengte * lengte);
        console.log(`je BMI is ${bmi.toFixed(2)}`);
        done = true;

    }catch(error){
        console.error(error)
    }
}while(done === false)

