import { Component } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { UtilityService } from '../services/utility.service';
import { SurveyService } from '../services/survey.service';
import { Survey } from '../viewmodels/survey';

@Component({
  selector: 'surveystart',
  templateUrl: './surveystart.component.html'
})
export class SurveyStartComponent  {
    public form: FormGroup;
    public showSuccess: boolean = false;
    public showError: boolean = false;
    private errorMessages: any = [];
    public id: string| null = null;
    public triedToSubmitForm: boolean = false;

  constructor(public router: Router, private utilityService: UtilityService, private surveyService: SurveyService) {
    this.form = <FormGroup>this.utilityService.generateReactiveForm(new FormGroup({}), new Survey());
    }

    private onError(err: any)
    {
        if (!err.ok && err._body) {
            var responseMessage = JSON.parse(err._body);
            if (responseMessage.errors) {
                this.errorMessages = responseMessage.errors;
            } else {
                this.errorMessages = [err.statusText];
            }
        } else {
            this.errorMessages = [err.statusText];
        }

        this.showSuccess = false;
        this.showError = true;
    }


    public start() {
      this.triedToSubmitForm = true;
        if (!this.form.valid) {
            return;
      }
      
        this.surveyService.addSurvey(<Survey>this.form.value)
            .subscribe(
            data => {
              this.router.navigate(['/question'], { queryParams: { surveyId: data, currentQuestionId: null } });
            }, (err) => this.onError(err));
    }
}
