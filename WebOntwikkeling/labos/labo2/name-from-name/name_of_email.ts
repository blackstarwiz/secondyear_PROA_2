import * as readline from "readline-sync";
let active : boolean = true;
let email : string = readline.question("Geef het email in: ");

do{
    let atMark : number = email.indexOf("@");
    let fullname : string = email.substring(0,atMark);
    let splitFull : string[] = fullname.split("");
    for(let char of splitFull){
        switch(char){
            case ".": case "-": case "_":
                
                let voornaam : string = fullname.substring(0,splitFull.indexOf(char));
                let achternaam : string = fullname.substring(splitFull.indexOf(char)+1,fullname.length);

                console.log(`voornaam: ${voornaam} achternaam: ${achternaam}`)
                break;
        }
    }
    console.log(fullname);

    
    active = false;
}while(active)