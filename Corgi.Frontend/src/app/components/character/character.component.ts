import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { GetCharacterDtoV1 } from '../../interfaces/get-character-dto-v1';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ActivatedRoute, Router } from '@angular/router';
import { CharacterService } from '../../services/character.service';

@Component({
  selector: 'app-character',
  imports: [ CommonModule, MatButtonModule, MatIconModule ],
  templateUrl: './character.component.html',
  styleUrl: './character.component.scss'
})
export class CharacterComponent {
  character!: GetCharacterDtoV1;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private characterService: CharacterService
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id === null) {
      return;
    }
    this.fetchCharacter(id);
  }

  fetchCharacter(id: string) {
    this.characterService.getCharacterById(id).subscribe({
      next: value => this.character = value,
      error: _ => this.router.navigate(['/not-found'])
    });
  }

  onDelete() {

  }

  onSave() {

  }
}
