import { Component, OnInit, AfterViewInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { UtilityService } from '../services/utility.service';
import { SurveyService } from '../services/survey.service';
import { SurveyAnswer } from '../viewmodels/surveyanswer';
import { Question } from '../viewmodels/question';
import 'rxjs/add/operator/filter';

@Component({
  selector: 'question',
  templateUrl: './question.component.html'
})
export class QuestionComponent implements OnInit, AfterViewInit  {
    public form: FormGroup;
    public showSuccess: boolean = false;
    public showError: boolean = false;
    private errorMessages: any = [];
    public id: string| null = null;
    public triedToSubmitForm: boolean = false;
    public question: Question = null;
  public currentQuestionId: string = null;
  public surveyId: string = null;
  public buttonLabel = "Next";

  constructor(private route: ActivatedRoute, public router: Router, private utilityService: UtilityService, private surveyService: SurveyService) {
    this.form = <FormGroup>this.utilityService.generateReactiveForm(new FormGroup({}), new SurveyAnswer());
    // override the route reuse strategy
    this.router.routeReuseStrategy.shouldReuseRoute = function () {
      return false;
    };
  }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        console.log('params', params);

        this.currentQuestionId = params.currentQuestionId;
        this.surveyId = params.surveyId;
      });

    this.surveyService.getNextQuestion(this.currentQuestionId)
      .subscribe(
        data => {
          this.question = data;
          if (this.question.isLast) {
            this.buttonLabel = 'Submit';
          }

        }, (err) => this.onError(err));
  }

  ngAfterViewInit() {
   
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
      this.showError = true;
    }

    public next() {
        this.triedToSubmitForm = true;
        if (!this.form.valid) {
            return;
      }

      let surveyAnswer = <SurveyAnswer>this.form.value
      surveyAnswer.surveyId = this.surveyId;

      this.surveyService.addSurveyAnswer(surveyAnswer)
        .subscribe(
          data => {
            if (this.question.isLast) {
              this.router.navigate(['/thankyou']);
            }
            else {
              this.router.navigate(['/question'], { queryParams: { surveyId: this.surveyId, currentQuestionId: this.question.id } });
            }
          }, (err) => this.onError(err));

    }
}
