import { Injectable, Inject } from '@angular/core';
import { Http, RequestOptions, Headers } from '@angular/http';

import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { Survey } from '../viewmodels/survey';
import { SurveyAnswer } from '../viewmodels/surveyanswer';

@Injectable()
export class SurveyService {
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    getNextQuestion(id: string): Observable<any> {
        return this.http.get(this.baseUrl + 'api/question',
            new RequestOptions({ headers: new Headers({ 'Content-Type': 'application/json' }), params: { id: id} }))
            .map((data) => data.json());
    }

    addSurvey(vm: Survey): Observable<any> {
        return this.http.post(this.baseUrl + 'api/survey', JSON.stringify(vm),
            new RequestOptions({ headers: new Headers({ 'Content-Type': 'application/json' }) }))
            .map((data) => data.json());
    }

    addSurveyAnswer(vm: SurveyAnswer): Observable<any> {
      return this.http.post(this.baseUrl + 'api/surveyanswer', JSON.stringify(vm),
        new RequestOptions({ headers: new Headers({ 'Content-Type': 'application/json' }) }))
        .map((data) => data.json());
    }
}
