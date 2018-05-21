export class Svar{
    svar: String;
    spørgsmål: String;
    rigtig: Boolean;

    /**
     *
     */
    constructor(svar:String,spørgsmål:String,rigtig:boolean) {
        this.svar=svar;
        this.spørgsmål = spørgsmål;
        this.rigtig = rigtig;
    }
}