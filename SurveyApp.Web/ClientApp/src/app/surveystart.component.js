"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var SurveyStartComponent = /** @class */ (function () {
    function SurveyStartComponent(utilityService, surveyService) {
        this.utilityService = utilityService;
        this.surveyService = surveyService;
        this.showSuccess = false;
        this.showError = false;
        this.errorMessages = [];
        this.id = null;
        this.triedToSubmitForm = false;
        //this.form = <FormGroup>this.utilityService.generateReactiveForm(new FormGroup({}), new Survey());
        //PalindromeValidator.apply(this.form);
    }
    SurveyStartComponent.prototype.onError = function (err) {
        if (!err.ok && err._body) {
            var responseMessage = JSON.parse(err._body);
            if (responseMessage.errors) {
                this.errorMessages = responseMessage.errors;
            }
            else {
                this.errorMessages = [err.statusText];
            }
        }
        else {
            this.errorMessages = [err.statusText];
        }
        this.showSuccess = false;
        this.showError = true;
    };
    SurveyStartComponent.prototype.start = function () {
        var _this = this;
        this.triedToSubmitForm = true;
        if (!this.form.valid) {
            return;
        }
        this.surveyService.addSurvey(this.form.value)
            .subscribe(function (data) {
            _this.id = data;
            //this.showSuccess = true;
            //this.showError = false;
            //let vm = <Palindrome>this.form.value;
            //vm.id = this.id;
            //this.phrases.push(vm);
        }, function (err) { return _this.onError(err); });
    };
    return SurveyStartComponent;
}());
exports.SurveyStartComponent = SurveyStartComponent;
//# sourceMappingURL=surveystart.component.js.map