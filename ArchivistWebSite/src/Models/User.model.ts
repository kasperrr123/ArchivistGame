export class User {
    username: string;
    password: string;
    type: number;
   
    constructor(username: string,password:string, type: number) {
        this.username = username;
        this.password = password;
        this.type = type;
        

    }

}