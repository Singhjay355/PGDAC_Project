﻿using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Repository.Configfolder
{
    public class ConfigRepository : IConfigRepository
    {
        private readonly AppDbContext _context;

        public ConfigRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Config> AddConfig(Config config)
        {
            _context.Configs.Add(config);
            await _context.SaveChangesAsync();
            return config;
        }

        public async Task<Config?> DeleteConfig(int configId)
        {
            var config = await _context.Configs.FindAsync(configId);
            if (config != null)
            {
                _context.Configs.Remove(config);
                await _context.SaveChangesAsync();
            }
            return config;
        }

        public async Task<IEnumerable<Config>> GetAllConfigs()
        {
            return await _context.Configs.ToListAsync();
        }

        public async Task<Config?> GetConfigById(int configId)
        {
            return await _context.Configs.FindAsync(configId);
        }

        public async Task<Config?> UpdateConfig(int configId, Config updatedConfig)
        {
            if (configId != updatedConfig.ConfigID)
            {
                return null;
            }

            _context.Entry(updatedConfig).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigExists(configId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return updatedConfig;
        }

        private bool ConfigExists(int configId)
        {
            return _context.Configs.Any(e => e.ConfigID == configId);
        }
    }
}
