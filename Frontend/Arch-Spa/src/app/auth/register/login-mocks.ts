import { UserAuth } from './user-auth';

export const LOGIN_MOCKS: UserAuth[] = [{
  username: 'marcos',
  bearerToken: 'asdfasdfasdfa',
  canAccessProducts: true,
  canAddProduct: true,
  canSaveProduct: true,
  canAccessCategories: true,
  canAddCategory: false
},{
  username: 'marcos2',
  bearerToken: 'asdfasdfasdfa2',
  canAccessProducts: true,
  canAddProduct: false,
  canSaveProduct: false,
  canAccessCategories: true,
  canAddCategory: true
}]
