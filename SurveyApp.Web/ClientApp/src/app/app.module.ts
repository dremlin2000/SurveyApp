import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SurveyStartComponent } from './surveystart.component';
import { QuestionComponent } from './question.component';
import { ThankYouComponent } from './thankyou.component';
import { UtilityService } from '../services/utility.service';
import { SurveyService } from '../services/survey.service';


@NgModule({
  declarations: [
    AppComponent,
    SurveyStartComponent,
    QuestionComponent,
    ThankYouComponent
  ],
  imports: [
    CommonModule,
    HttpModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    UtilityService,
    SurveyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
