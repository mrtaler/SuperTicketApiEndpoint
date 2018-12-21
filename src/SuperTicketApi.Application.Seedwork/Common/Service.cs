﻿namespace SuperTicketApi.Application.Seedwork.Common
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SuperTicketApi.Domain.Seedwork;
    using SuperTicketApi.Domain.Seedwork.Repository;
    using SuperTicketApi.Infrastructure.Crosscutting.Localization;
    using SuperTicketApi.Infrastructure.Crosscutting.Validator;

    public abstract class Service<TEntity, TEntityDTO> : IService<TEntity, TEntityDTO>
    where TEntity : Entity, new()
    where TEntityDTO : Entity, new()
    {
        protected IRepository<TEntity> _repository;
        protected ILocalization _resources;
        protected IEntityValidator _validator;

        public Service(IRepository<TEntity> repository)
        {
            this._repository = repository;
            this._resources = LocalizationFactory.CreateLocalResources();
            this._validator = EntityValidatorFactory.CreateValidator();
        }

        #region Private Methods
        private TEntity AddBase(TEntity item)
        {
            if (this._validator.IsValid<TEntity>(item))
            {
                this._repository.Add(item);
                this._repository.UnitOfWork.Commit();
                return item;
            }
            else
            {
                throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
            }
        }

        private async Task<TEntity> AddBaseAsync(TEntity item)
        {
            if (this._validator.IsValid<TEntity>(item))
            {
                this._repository.Add(item);
                await this._repository.UnitOfWork.CommitAsync();
                return item;
            }
            else
            {
                throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
            }
        }

        private IEnumerable<TEntity> AddBase(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                if (this._validator.IsValid<TEntity>(item))
                {
                    this._repository.Add(item);
                }
                else
                {
                    throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
                }
            }

            this._repository.UnitOfWork.Commit();
            return items;
        }

        private async Task<IEnumerable<TEntity>> AddBaseAsync(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                if (this._validator.IsValid<TEntity>(item))
                {
                    this._repository.Add(item);
                }
                else
                {
                    throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
                }
            }

            await this._repository.UnitOfWork.CommitAsync();
            return items;

        }

        private void RemoveBase(TEntity item)
        {
            this._repository.Remove(item);
            this._repository.UnitOfWork.Commit();
        }

        private async Task RemoveBaseAsync(TEntity item)
        {
            this._repository.Remove(item);
            await this._repository.UnitOfWork.CommitAsync();
        }

        private void RemoveBase(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                if (item != null) this._repository.Remove(item);
            }

            this._repository.UnitOfWork.Commit();
        }

        private async Task RemoveBaseAsync(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                if (item != null) this._repository.Remove(item);
            }

            await this._repository.UnitOfWork.CommitAsync();
        }

        private TEntity ModifyBase(TEntity item)
        {
            if (this._validator.IsValid<TEntity>(item))
            {
                this._repository.Modify(item);
                this._repository.UnitOfWork.Commit();
                return item;
            }
            else
            {
                throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
            }
        }

        private async Task<TEntity> ModifyBaseAsync(TEntity item)
        {
            if (this._validator.IsValid<TEntity>(item))
            {
                this._repository.Modify(item);
                await this._repository.UnitOfWork.CommitAsync();
                return item;
            }
            else
            {
                throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
            }
        }

        private TEntity ModifyBase(object id, TEntity item)
        {
            var persisted = this.Get(id);
            if (persisted != null)
            {
                if (this._validator.IsValid<TEntity>(item))
                {
                    this._repository.Merge(persisted, item);
                    this._repository.UnitOfWork.Commit();
                }
                else
                {
                    throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
                }
            }

            return persisted;
        }

        private async Task<TEntity> ModifyBaseAsync(object id, TEntity item)
        {
            var persisted = this.Get(id);
            if (persisted != null)
            {
                if (this._validator.IsValid<TEntity>(item))
                {
                    this._repository.Merge(persisted, item);
                    await this._repository.UnitOfWork.CommitAsync();
                }
                else
                {
                    throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
                }
            }

            return persisted;
        }

        private IEnumerable<TEntity> ModifyBase(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                if (this._validator.IsValid<TEntity>(item))
                {
                    this._repository.Modify(item);
                }
                else
                {
                    throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
                }
            }

            this._repository.UnitOfWork.Commit();
            return items;
        }

        private async Task<IEnumerable<TEntity>> ModifyBaseAsync(IEnumerable<TEntity> items)
        {
            foreach (var item in items)
            {
                if (this._validator.IsValid<TEntity>(item))
                {
                    this._repository.Modify(item);

                }
                else
                {
                    throw new ApplicationValidationErrorsException(this._validator.GetInvalidMessages<TEntity>(item));
                }
            }

            await this._repository.UnitOfWork.CommitAsync();
            return items;
        }

        #endregion

        #region Public Methods
        public virtual TEntity Add(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return this.AddBase(item);
        }

        public virtual IEnumerable<TEntity> Add(IEnumerable<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return this.AddBase(items);
        }

        public virtual TEntityDTO Add(TEntityDTO item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entity = this.AddBase(item.ProjectedAs<TEntity>());

            if (entity != null)
            {
                return entity.ProjectedAs<TEntityDTO>();
            }

            return null;
        }

        public virtual IList<TEntityDTO> Add(IList<TEntityDTO> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entities = this.AddBase(items.ProjectedAsCollection<TEntity>());

            if (entities != null)
            {
                return entities.ProjectedAsCollection<TEntityDTO>();
            }

            return null;
        }

        public virtual async Task<TEntity> AddAsync(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return await this.AddBaseAsync(item);
        }

        public virtual async Task<IEnumerable<TEntity>> AddAsync(IEnumerable<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return await this.AddBaseAsync(items);
        }

        public virtual async Task<TEntityDTO> AddAsync(TEntityDTO item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entity = await this.AddBaseAsync(item.ProjectedAs<TEntity>());

            if (entity != null)
            {
                return entity.ProjectedAs<TEntityDTO>();
            }

            return null;
        }

        public virtual async Task<IList<TEntityDTO>> AddAsync(IList<TEntityDTO> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entities = await this.AddBaseAsync(items.ProjectedAsCollection<TEntity>());

            if (entities != null)
            {
                return entities.ProjectedAsCollection<TEntityDTO>();
            }

            return null;
        }

        public virtual void Remove(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            this.RemoveBase(item);
        }

        public virtual void Remove(IEnumerable<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            this.RemoveBase(items);
        }

        public virtual void Remove(TEntityDTO item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            this.RemoveBase(item.ProjectedAs<TEntity>());
        }

        public virtual void Remove(IList<TEntityDTO> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            this.RemoveBase(items.ProjectedAsCollection<TEntity>());
        }

        public virtual void Remove(object id)
        {
            if (id == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            this.RemoveBase(this.Get(id));
        }

        public virtual void Remove(IEnumerable<object> ids)
        {
            if (ids == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            List<TEntity> entities = new List<TEntity>();

            foreach (var id in ids)
            {
                if (id != null) entities.Add(this.Get(id));
            }

            this.RemoveBase(entities);
        }

        public virtual async Task RemoveAsync(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            await this.RemoveBaseAsync(item);
        }

        public virtual async Task RemoveAsync(IEnumerable<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            await this.RemoveBaseAsync(items);
        }

        public virtual async Task RemoveAsync(TEntityDTO item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            await this.RemoveBaseAsync(item.ProjectedAs<TEntity>());
        }

        public virtual async Task RemoveAsync(IList<TEntityDTO> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            await this.RemoveBaseAsync(items.ProjectedAsCollection<TEntity>());
        }

        public virtual async Task RemoveAsync(object id)
        {
            if (id == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            await this.RemoveBaseAsync(this.Get(id));
        }

        public virtual async Task RemoveAsync(IEnumerable<object> ids)
        {
            if (ids == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            List<TEntity> entities = new List<TEntity>();

            foreach (var id in ids)
            {
                if (id != null) entities.Add(this.Get(id));
            }

            await this.RemoveBaseAsync(entities);
        }

        public virtual TEntity Modify(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return this.ModifyBase(item);
        }

        public virtual IEnumerable<TEntity> Modify(IEnumerable<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return this.ModifyBase(items);
        }

        public virtual TEntityDTO Modify(TEntityDTO item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entity = this.ModifyBase(item.ProjectedAs<TEntity>());
            if (entity != null)
            {
                return entity.ProjectedAs<TEntityDTO>();
            }

            return null;
        }

        public virtual IList<TEntityDTO> Modify(IList<TEntityDTO> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entities = this.ModifyBase(items.ProjectedAsCollection<TEntity>());
            if (entities != null)
            {
                return entities.ProjectedAsCollection<TEntityDTO>();
            }

            return null;
        }

        public virtual TEntity Modify(object id, TEntity item)
        {
            if (id == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            return this.ModifyBase(id, item);
        }

        public virtual TEntityDTO Modify(object id, TEntityDTO item)
        {
            if (id == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            var entity = this.ModifyBase(id, item.ProjectedAs<TEntity>());
            if (entity != null)
            {
                return entity.ProjectedAs<TEntityDTO>();
            }

            return null;
        }

        public virtual async Task<TEntity> ModifyAsync(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return await this.ModifyBaseAsync(item);
        }

        public virtual async Task<IEnumerable<TEntity>> ModifyAsync(IEnumerable<TEntity> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            return await this.ModifyBaseAsync(items);
        }

        public virtual async Task<TEntityDTO> ModifyAsync(TEntityDTO item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entity = await this.ModifyBaseAsync(item.ProjectedAs<TEntity>());
            if (entity != null)
            {
                return entity.ProjectedAs<TEntityDTO>();
            }

            return null;

        }

        public virtual async Task<IList<TEntityDTO>> ModifyAsync(IList<TEntityDTO> items)
        {
            if (items == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            var entities = await this.ModifyBaseAsync(items.ProjectedAsCollection<TEntity>());
            if (entities != null)
            {
                return entities.ProjectedAsCollection<TEntityDTO>();
            }

            return null;

        }

        public virtual async Task<TEntity> ModifyAsync(object id, TEntity item)
        {
            if (id == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            return await this.ModifyBaseAsync(id, item);
        }

        public virtual async Task<TEntityDTO> ModifyAsync(object id, TEntityDTO item)
        {
            if (id == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_Null_Parameters_Error));
            }

            var entity = await this.ModifyBaseAsync(id, item.ProjectedAs<TEntity>());
            if (entity != null)
            {
                return entity.ProjectedAs<TEntityDTO>();
            }

            return null;
        }

        public virtual void Refresh(TEntity item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            this._repository.Refresh(item);
        }

        public virtual void Refresh(TEntityDTO item)
        {
            if (item == null)
            {
                throw new ArgumentException(this._resources.GetStringResource(LocalizationKeys.Application.validation_No_Records_Found_Error));
            }

            this._repository.Refresh(item.ProjectedAs<TEntity>());
        }

        public virtual TEntity Get(object id)
        {
            if (id != null)
                return this._repository.Get(id);
            else
                return null;
        }

        public virtual TEntityDTO GetDTO(object id)
        {
            TEntity entity = null;
            if (id != null) entity = this._repository.Get(id);
            if (entity != null) return entity.ProjectedAs<TEntityDTO>();
            return null;
        }

        public virtual async Task<TEntity> GetAsync(object id)
        {
            if (id != null)
                return await this._repository.GetAsync(id);
            else
                return null;
        }

        public virtual async Task<TEntityDTO> GetDTOAsync(object id)
        {
            TEntity entity = null;
            if (id != null) entity = await this._repository.GetAsync(id);
            if (entity != null) return entity.ProjectedAs<TEntityDTO>();
            return null;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return this._repository.GetAll();
        }

        public virtual IList<TEntityDTO> GetAllDTO()
        {
            var entities = this._repository.GetAll();
            if (entities != null)
            {
                return entities.ProjectedAsCollection<TEntityDTO>();
            }

            return null;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        public virtual async Task<IList<TEntityDTO>> GetAllDTOAsync()
        {
            var entities = await this._repository.GetAllAsync();
            if (entities != null)
            {
                return entities.ProjectedAsCollection<TEntityDTO>();
            }

            return null;
        }

        public virtual void Dispose()
        {
            this._repository.Dispose();
        }

        #endregion


    }
}
