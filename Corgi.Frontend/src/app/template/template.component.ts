import { Component } from '@angular/core';
import { TemplateService } from '../template.service';
import { GetTemplateDtoV1 } from '../get-template-dto-v1';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { TemplateFieldComponent } from "../template-field/template-field.component";

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

  onAddField() {
    this.templateService.addTemplateField(this.template.id).subscribe({
      next: field => this.template.fields.push(field)
    });
  }
}
