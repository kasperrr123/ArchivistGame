import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Http } from '@angular/http';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";

@Component({
  selector: 'TestUpload',
  templateUrl: './TestUpload.component.html',
  styleUrls: ['./TestUpload.component.css']
})
export class TestUploadComponent implements OnInit {
  url: string = "http://localhost:3000/UploadPicture";
  form: FormGroup;
  loading: boolean = false;
  formData: FormData = new FormData();

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
