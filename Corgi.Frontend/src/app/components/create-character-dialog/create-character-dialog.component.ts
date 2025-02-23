import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { CharacterService } from '../../services/character.service';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { TemplateService } from '../../services/template.service';
import { GetTemplateDtoV1 } from '../../models/get-template-dto-v1';
import { TemplateResponseDtoV1 } from '../../models/template-response-dto-v1';
import { MatSelectModule } from '@angular/material/select';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-character-dialog',
  imports: [ FormsModule, MatDialogModule, MatFormFieldModule, MatButtonModule, MatInputModule, MatSelectModule ],
  templateUrl: './create-character-dialog.component.html',
  styleUrl: './create-character-dialog.component.scss'
})
export class CreateCharacterDialogComponent {
  name: string = '';
  templates: GetTemplateDtoV1[] = [];
  selectedTemplate: string = '';

  constructor(
    private characterService: CharacterService
    , private templateService: TemplateService
    , private dialogRef: MatDialogRef<CreateCharacterDialogComponent>
    , private router: Router
  ) {}

  ngOnInit() {
    this.templateService.getAllTemplates().subscribe({
      next: (value: TemplateResponseDtoV1) => {
        this.templates = value.templates;
        this.selectedTemplate = this.templates[0].id;
      },
    });
  }

  onConfirm() {
    this.characterService.createNewCharacter({ name: this.name, template: this.selectedTemplate}).subscribe({
      next: v => {
        this.router.navigate(['/characters/' + v.id]);
        this.dialogRef.close();
      },
      error: e => console.error(e)
    });
  }
}
