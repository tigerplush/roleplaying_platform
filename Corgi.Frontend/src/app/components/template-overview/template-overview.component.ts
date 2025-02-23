import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog } from '@angular/material/dialog';
import { CreateTemplateDialogComponent } from '../create-template-dialog/create-template-dialog.component';
import { TemplateService } from '../../services/template.service';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { GetTemplateDtoV1 } from '../../models/get-template-dto-v1';

@Component({
  selector: 'app-template-overview',
  imports: [ CommonModule, MatButtonModule, MatIconModule, RouterModule ],
  templateUrl: './template-overview.component.html',
  styleUrl: './template-overview.component.scss'
})
export class TemplateOverviewComponent {
  templates: GetTemplateDtoV1[] = [];

  constructor(
    private dialog: MatDialog
    , private templateService: TemplateService
    , private router: Router
  ) {
  }

  ngOnInit() {
    this.templateService.getAllTemplates().subscribe(templates => {
      this.templates = templates.templates;
    })
  }

  openNewTemplateDialog() {
    this.dialog.open(CreateTemplateDialogComponent);
  }
}
