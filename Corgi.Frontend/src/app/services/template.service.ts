import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { AddTemplateDtoV1 } from '../models/add-template-dto-v1';
import { AddTemplateFieldDtoV1 } from '../models/add-template-field-dto-v1';
import { GetTemplateDtoV1 } from '../models/get-template-dto-v1';
import { TemplateResponseDtoV1 } from '../models/template-response-dto-v1';
import { GetTemplateFieldDtoV1 } from '../models/get-template-field-dto-v1';

@Injectable({
  providedIn: 'root'
})
export class TemplateService {
  private readonly resource = '/templates';
  constructor(private http: HttpClient) { }

  createNewTemplate(name: string) {
    return this.http.post<GetTemplateDtoV1>(environment.baseUrl + this.resource, new AddTemplateDtoV1(name));
  }

  getAllTemplates() {
    return this.http.get<TemplateResponseDtoV1>(environment.baseUrl + this.resource);
  }

  getTemplateById(templateId: string) {
    return this.http.get<GetTemplateDtoV1>(environment.baseUrl + this.resource + '/' + templateId);
  }

  deleteTemplateById(templateId: string) {
    return this.http.delete(environment.baseUrl + this.resource + '/' + templateId);
  }

  addTemplateField(templateId: string) {
    return this.http.post<GetTemplateFieldDtoV1>(environment.baseUrl + this.resource + '/' + templateId + '/fields', new AddTemplateFieldDtoV1());
  }
  
  updateTemplateField(templateId: string, field: GetTemplateFieldDtoV1) {
    return this
      .http
      .put<GetTemplateFieldDtoV1>(`${environment.baseUrl}${this.resource}/${templateId}/fields/${field.id}`, field);
  }

  deleteTemplateField(templateId: string, fieldId: string) {
    return this
      .http
      .delete(`${environment.baseUrl}${this.resource}/${templateId}/fields/${fieldId}`);
  }
}
