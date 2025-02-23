import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { debounceTime, Subject } from 'rxjs';
import { GetTemplateFieldDtoV1 } from '../../models/get-template-field-dto-v1';

@Component({
  selector: 'app-template-field',
  imports: [ CommonModule, FormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatIconModule, MatButtonModule ],
  templateUrl: './template-field.component.html',
  styleUrl: './template-field.component.scss'
})
export class TemplateFieldComponent {
  @Input() field!: GetTemplateFieldDtoV1;
  private inputChange$ = new Subject<void>();
  @Output() onDelete = new EventEmitter<GetTemplateFieldDtoV1>();
  @Output() onChange = new EventEmitter<GetTemplateFieldDtoV1>();


  constructor() {
    this.inputChange$.pipe(
      debounceTime(1000),
    )
    .subscribe(() => {
      this.onChange.emit(this.field);
    });
  }

  ngOnDestroy() {
    this.inputChange$.unsubscribe();
  }

  onNgModelChange() {
    this.inputChange$.next();
  }

  onClickDelete() {
    this.onDelete.emit(this.field);
  }
}
