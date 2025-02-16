import { Component, Input } from '@angular/core';
import { GetTemplateFieldDtoV1 } from '../get-template-field-dto-v1';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-template-field',
  imports: [ CommonModule, FormsModule, MatFormFieldModule, MatInputModule, MatSelectModule, MatIconModule, MatButtonModule ],
  templateUrl: './template-field.component.html',
  styleUrl: './template-field.component.scss'
})
export class TemplateFieldComponent {
  @Input() field!: GetTemplateFieldDtoV1;
}
