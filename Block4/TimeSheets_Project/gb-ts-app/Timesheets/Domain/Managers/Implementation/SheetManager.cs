﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Aggregates.SheetAggregate;
using Timesheets.Domain.Interfaces;
using Timesheets.Models;
using Timesheets.Models.Dto;

namespace Timesheets.Domain.Implementation
{
    public class SheetManager: ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;
        private readonly ISheetAggregateRepo _sheetAggregateRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
        }

        public async Task<Sheet> GetItem(Guid id)
        {
            return await _sheetRepo.GetItem(id);
        }

        public async Task<IEnumerable<Sheet>> GetItems()
        {
            return await _sheetRepo.GetItems();
        }

        public async Task<Guid> Create(SheetRequest sheetRequest)
        {
            var sheet = SheetAggregate.CreateFromSheetRequest(sheetRequest);


            await _sheetRepo.Add(sheet);
            
            return sheet.Id;
        }

        public async Task Approve(Guid sheetId)
        {
            var sheet = await _sheetAggregateRepo.GetItem(sheetId);
            sheet.ApproveSheet();
            _sheetAggregateRepo.Update(sheet);
        }

        public async Task Update(Guid id, SheetRequest sheetRequest)
        {
            var sheet = SheetAggregate.CreateFromSheetRequest(sheetRequest);
            await _sheetRepo.Update(sheet);
        }
    }
}