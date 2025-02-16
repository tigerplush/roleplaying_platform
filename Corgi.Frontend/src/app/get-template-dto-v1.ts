export class GetTemplateDtoV1 {
    constructor(
        public id: string
        , public name: string
        , public fields: string[]
        , public createdAt: string
        , public lastModified: string
    ) {

    }
}
