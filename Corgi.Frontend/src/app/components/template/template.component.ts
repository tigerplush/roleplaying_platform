import { Component } from '@angular/core';
import { TemplateService } from '../../services/template.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TemplateFieldComponent } from "../template-field/template-field.component";
import { GetTemplateDtoV1 } from '../../models/get-template-dto-v1';
import { GetTemplateFieldDtoV1 } from '../../models/get-template-field-dto-v1';

@Component({
  selector: 'app-template',
  imports: [CommonModule, MatIconModule, MatButtonModule, TemplateFieldComponent],
  templateUrl: './template.component.html',
  styleUrl: './template.component.scss'
})
export class TemplateComponent {
  template!: GetTemplateDtoV1;

  constructor(
    private templateService: TemplateService
    , private route: ActivatedRoute
    , private router: Router
  ) {

  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id === null) {
      return;
    }
    this.fetchTemplate(id);
  }

  fetchTemplate(id: string) {
    this.templateService.getTemplateById(id).subscribe({
      next: value => this.template = value,
      error: _ => this.router.navigate(['/not-found'])
    });
  }

  onDelete() {
    this.templateService.deleteTemplateById(this.template.id).subscribe({
      next: _ => this.router.navigate(['/templates'])
    })
  }

  onSave() {

  }

  onAddField() {
    this.templateService.addTemplateField(this.template.id).subscribe({
      next: field => this.template.fields.push(field)
    });
  }

  onFieldDelete(value: GetTemplateFieldDtoV1) {
    this.templateService.deleteTemplateField(this.template.id, value.id).subscribe({
      complete: () => this.fetchTemplate(this.template.id)
    })
  }

  onFieldChange(value: GetTemplateFieldDtoV1) {
    this.templateService.updateTemplateField(this.template.id, value).subscribe({
      complete: () => this.fetchTemplate(this.template.id)
    });
  }
}
