import { GetTemplateFieldDtoV1 } from "./get-template-field-dto-v1";

export class GetTemplateDtoV1 {
    constructor(
        public id: string
        , public name: string
        , public fields: GetTemplateFieldDtoV1[]
        , public createdAt: string
        , public lastModified: string
    ) {

    }
}
