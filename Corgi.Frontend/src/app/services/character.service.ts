import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { GetCharacterDtoV1 } from '../interfaces/get-character-dto-v1';
import { AddCharacterDtoV1 } from '../interfaces/add-character-dto-v1';

@Injectable({
  providedIn: 'root'
})
export class CharacterService {
  private readonly resource: string = 'characters';
  constructor(private http: HttpClient) { }

  createNewCharacter(character: AddCharacterDtoV1) {
    return this.http.post<GetCharacterDtoV1>(`${environment.baseUrl}/${this.resource}`, character);
  }
}
