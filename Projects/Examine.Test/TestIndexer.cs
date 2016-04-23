using System;
using System.Collections.Generic;
using System.Linq;
using Examine.LuceneEngine.Faceting;
using Examine.LuceneEngine.Indexing;
using Examine.LuceneEngine.Providers;
using Lucene.Net.Analysis;
using Lucene.Net.Store;

namespace Examine.Test
{
    public class TestIndexer : LuceneIndexer
    {
        public TestIndexer(IEnumerable<FieldDefinition> fieldDefinitions, FacetConfiguration facetConfiguration, Directory luceneDirectory, Analyzer defaultAnalyzer, IDictionary<string, Func<string, IIndexValueType>> indexValueTypes = null)
            : base(fieldDefinitions, luceneDirectory, defaultAnalyzer, null, facetConfiguration, indexValueTypes)
        {
        }

        public TestIndexer(IEnumerable<FieldDefinition> fieldDefinitions, Directory luceneDirectory, Analyzer defaultAnalyzer, IDictionary<string, Func<string, IIndexValueType>> indexValueTypes = null)
            : base(fieldDefinitions, luceneDirectory, defaultAnalyzer, null, new FacetConfiguration(), indexValueTypes)
        {
        }

        public TestIndexer(Directory luceneDirectory, Analyzer defaultAnalyzer, FacetConfiguration facetConfiguration = null)
            : base(new FieldDefinition[] { }, luceneDirectory, defaultAnalyzer, null, facetConfiguration)
        {
        }

        [Obsolete("This is for legacy tests only")]
        public TestIndexer(IIndexCriteria indexerData, Directory luceneDirectory, Analyzer analyzer)
            : base(indexerData, luceneDirectory, analyzer)
        {
        }

        private IEnumerable<ValueSet> AllData()
        {
            var data = new List<ValueSet>();
            for (int i = 0; i < 100; i++)
            {
                data.Add(new ValueSet(i, "category" + (i % 2), new { item1 = "value" + i, item2 = "value" + i }));
            }
            return data;
        }

        protected override void PerformIndexAll(string category)
        {
            IndexItems(AllData().Where(x => x.IndexCategory == category).ToArray());
        }

        protected override void PerformIndexRebuild()
        {
            IndexItems(AllData().ToArray());
        }
    }
}