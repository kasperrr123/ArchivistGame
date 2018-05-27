import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Http } from '@angular/http';
import { FormBuilder, FormGroup, Validators, AbstractControl } from "@angular/forms";
import { Emne } from "../../Models/Emne.model";
import { Svar } from "../../Models/Svar.model";
import { Spørgsmål } from "../../Models/Spørgsmål.model";

@Component({
  selector: 'AddGame',
  templateUrl: './AddGame.component.html',
  styleUrls: ['./AddGame.component.css']
})
export class AddGameComponent implements OnInit {
  uploadEmnePictureURL: string = "http://localhost:3000/UploadPicture/topic/";
  uploadQuestionPictureURL: string = "http://localhost:3000/UploadPicture/question/";
  emneURL: string = "http://localhost:3000/emner"


  emneForm: FormGroup;
  spørgsmålForm: FormGroup;

  formData: FormData = new FormData();
  emneBillede: FormData = new FormData();

  display = 'none';

  loading: boolean = false;

  questions = false

  emne: Emne;
  listOfEmner: Emne[];


  @ViewChild('fileInput') fileInput: ElementRef;

  constructor(private http: Http, private fb: FormBuilder) {



  }

  createEmneForm() {
    this.emneForm = this.fb.group({
      emne: [null, Validators.required],
      beskrivelse: [null, Validators.required],
      emneBillede: [null, Validators.required]

    })

  }
  createForm() {
    this.spørgsmålForm = this.fb.group({
      picture: null
    });
  }

  onSubmit() {

    this.loading = true;

    this.http.post(this.uploadQuestionPictureURL, this.formData).subscribe(data => {
      alert(data);
      this.loading = false;
    }, error => { console.log(error) });

  }

  addEmne(values) {
    this.http.post(this.uploadEmnePictureURL, this.emneBillede).subscribe(data => {
      if (data.status == 200) {
        var nytemne = new Emne(values.emne, values.beskrivelse, 0, data.text().substring(1,data.text().length-1));
        this.listOfEmner.push(nytemne);
        this.http.post(this.emneURL, nytemne).subscribe(data => {
          if (data.status == 201) {
            alert("Tilføjet nyt emne");
            this.emneForm.reset();
          } else {
            alert(data + "kontakt admin emne blev ikke uploadet")
          }
        })
      } else {
        alert(data + "kontakt admin Billede blev ikke uploadet")
      }
    })
  }

  ngOnInit() {
    this.createEmneForm();

    this.http.get(this.emneURL).subscribe(data => {
      this.listOfEmner = data.json() as Emne[]
    }, error => { console.log(error) });


  }

  openModalDialog() {
    this.display = 'block';
  }

  closeModalDialog() {
    this.display = 'none';
  }
  clearFile() {
    // this.form.get('picture').setValue(null);
    // this.fileInput.nativeElement.value = '';
  }

  onFileChange(event) {
    const eventObj: MSInputMethodContext = <MSInputMethodContext>event;
    const target: HTMLInputElement = <HTMLInputElement>eventObj.target;
    const files: FileList = target.files;

    for (let i = 0; i < files.length; i++) {
      this.formData.append('file', files[i]);
    }
  }

  onEmneFileChange(event) {
    this.emneBillede = new FormData();
    const eventObj: MSInputMethodContext = <MSInputMethodContext>event;
    const target: HTMLInputElement = <HTMLInputElement>eventObj.target;
    const files: FileList = target.files;

    for (let i = 0; i < files.length; i++) {
      this.emneBillede.append('file', files[i]);
    }
  }

  onSelectChange(event) {
    if (this.questions) {
      this.questions = false;
    } else if (!this.questions) {
      this.questions = true;
    }
  }

}
