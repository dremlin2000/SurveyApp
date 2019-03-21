import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SurveyStartComponent } from './surveystart.component';
import { QuestionComponent } from './question.component';
import { ThankYouComponent } from './thankyou.component';

const routes: Routes = [
  { path: '', redirectTo: 'survey', pathMatch: 'full' },
  //{ path: '**', redirectTo: 'survey' },
  { path: 'survey', component: SurveyStartComponent },
  { path: 'question', component: QuestionComponent },
  { path: 'thankyou', component: ThankYouComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true, onSameUrlNavigation: 'reload' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
