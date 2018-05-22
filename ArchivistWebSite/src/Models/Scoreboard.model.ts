export class Scoreboard{
    spillernavn: String;
    emne: String;
    resultat: String;
    point: Number;

    /**
     *
     */
    constructor(spillernavn:String,emne:String,resultat:String,point:Number) {
        this.spillernavn=spillernavn;
        this.emne = emne;
        this.resultat = resultat;
        this.point = point;
    }
}