import { ParamCategory } from './params.models';

export interface ParamMatrix {
  ID?: number;
  Name?: string;
  Code?: string;
  Description?: string;
  ParamCategories: ParamCategory[];
}
