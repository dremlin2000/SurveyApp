import { Answer } from '../viewmodels/answer';

export class Question {
  id: string | null = null;
  questionText: string | null = null;
  answers: Array<Answer> = new Array<Answer>();
  isLast: boolean = false;
}
