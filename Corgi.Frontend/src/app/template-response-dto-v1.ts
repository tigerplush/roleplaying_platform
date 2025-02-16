import { GetTemplateDtoV1 } from "./get-template-dto-v1";

export class TemplateResponseDtoV1 {
    constructor(public templates: GetTemplateDtoV1[]) {
        
    }
}
