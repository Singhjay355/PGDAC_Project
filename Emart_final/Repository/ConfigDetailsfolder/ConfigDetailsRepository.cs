using Emart_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Emart_final.Repository.ConfigDetailsfolder
{
    public class ConfigDetailsRepository : IConfigDetailsRepository
    {
        private readonly AppDbContext context;

        public ConfigDetailsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<ConfigDetails> AddConfigDetails(ConfigDetails configDetails)
        {
            context.ConfigDetails.Add(configDetails);
            await context.SaveChangesAsync();
            return configDetails;
        }

        public async Task<ConfigDetails?> DeleteConfigDetails(int configDetailsId)
        {
            ConfigDetails configDetails = await context.ConfigDetails.FindAsync(configDetailsId);
            if (configDetails != null)
            {
                context.ConfigDetails.Remove(configDetails);
                await context.SaveChangesAsync();
            }
            return configDetails;
        }

        public async Task<ConfigDetails> GetConfigDetailsById(int configDetailsId)
        {
            var configDetails = await context.ConfigDetails.FindAsync(configDetailsId);
            return configDetails;
        }

        public async Task<ConfigDetails?> UpdateConfigDetails(int configDetailsId, ConfigDetails updatedConfigDetails)
        {
            if (configDetailsId != updatedConfigDetails.configDetailsID)
            {
                return null;
            }

            context.Entry(updatedConfigDetails).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigDetailsExists(configDetailsId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return updatedConfigDetails;
        }

        private bool ConfigDetailsExists(int configDetailsId)
        {
            return context.ConfigDetails.Any(e => e.configDetailsID == configDetailsId);
        }
    }
}
