export class Emne{
    emne:String;
    beskrivelse:String;
    antalBrugt:Number;
    billede: String;

    /**
     *
     */
    constructor(emne:String,beskrivelse:String,antalBrugt:Number,billede:String) {
        this.emne=emne;
        this.beskrivelse = beskrivelse;
        this.antalBrugt = antalBrugt;
        this.billede = billede;
    }
}