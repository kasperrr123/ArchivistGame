import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './NavMenu/NavMenu.component';
import { HomeComponent} from './Home/Home.component';
import { TestUploadComponent } from './TestUpload/TestUpload.component';
import { AddGameComponent } from './AddGame/AddGame.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    TestUploadComponent,
    AddGameComponent
],
  imports: [
    BrowserModule,
    CommonModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'TestUpload', component: TestUploadComponent },
      { path: 'addGame', component: AddGameComponent },
      { path: '**', redirectTo: 'home' }

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
