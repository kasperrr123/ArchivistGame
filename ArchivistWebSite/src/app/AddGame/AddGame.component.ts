import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Http } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'AddGame',
  templateUrl: './AddGame.component.html',
  styleUrls: ['./AddGame.component.css']
})
export class AddGameComponent implements OnInit {
  url: string = "http://localhost:3000/UploadPicture/question/";
  form: FormGroup;
  loading: boolean = false;
  formData: FormData = new FormData();
  display='none';
  questions = true;

  @ViewChild('fileInput') fileInput: ElementRef;

  constructor(private http: Http, private fb: FormBuilder) {
    this.createForm();
  }

  createForm() {
    this.form = this.fb.group({
      picture: null
    });
  }
  onSubmit() {
    const formModel = this.form.value;
    this.loading = true;

    this.http.post(this.url, this.formData).subscribe(data => {
      alert(data);
    }, error => { console.log(error) });

  }
  ngOnInit() {
  }
  
  openModalDialog(){
    this.display='block';
  }

  closeModalDialog(){
    this.display = 'none';
  }
  clearFile() {
    this.form.get('picture').setValue(null);
    this.fileInput.nativeElement.value = '';
  }

  onFileChange(event) {
    const eventObj: MSInputMethodContext = <MSInputMethodContext>event;
    const target: HTMLInputElement = <HTMLInputElement>eventObj.target;
    const files: FileList = target.files;

    for (let i = 0; i < files.length; i++) {
      this.formData.append('file', files[i]);
    }
  }

}
